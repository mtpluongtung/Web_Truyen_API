pipeline {
    agent any

    environment {
        DOTNET_VERSION = '8.0'               // Đặt phiên bản .NET phù hợp
        DEPLOY_SERVER = 'user@your-server-ip' // Server từ xa để triển khai
        DEPLOY_PATH = '/var/www/dotnet-api'   // Thư mục triển khai trên server
        SONARQUBE_ENV = 'SonarQube'          // Tên môi trường SonarQube trong Jenkins
    }

    stages {
        stage('Clone Repository') {
            steps {
                git branch: 'dev', url: 'https://github.com/mtpluongtung/Web_Truyen_API.git'
            }
        }

        stage('Restore Dependencies') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Build Application') {
            steps {
                sh 'dotnet build --configuration Release'
            }
        }

        stage('Analyze with SonarQube') {
            steps {
                withSonarQubeEnv('SonarQube') {
                    sh '''
                        dotnet sonarscanner begin \
                            /k:"your-project-key" \
                            /d:sonar.host.url="http://your-sonarqube-server" \
                            /d:sonar.login="your-sonarqube-token"
                        dotnet build
                        dotnet sonarscanner end \
                            /d:sonar.login="your-sonarqube-token"
                    '''
                }
            }
        }

        stage('Publish Application') {
            steps {
                sh 'dotnet publish -c Release -o ./publish'
            }
        }

        stage('Deploy to Server') {
            steps {
                sshagent(['your-ssh-credential-id']) {
                    sh '''
                        scp -r ./publish/* $DEPLOY_SERVER:$DEPLOY_PATH
                        ssh $DEPLOY_SERVER "sudo systemctl restart dotnet-api.service"
                    '''
                }
            }
        }
    }

    post {
        success {
            echo 'Build, Analysis, and Deployment Successful!'
        }
        failure {
            echo 'Build or Deployment Failed!'
        }
    }
}
