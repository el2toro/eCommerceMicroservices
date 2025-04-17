pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/el2toro/eCommerceMicroservices.git'
            }
        }

        stage('Build & Deploy with Docker Compose') {
            steps {
                script {
                    
                     bat '''
                         cd src
                         docker-compose -f docker-compose.yml -f docker-compose.override.yml down
                         docker-compose -f docker-compose.yml -f docker-compose.override.yml build
                         docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
                         '''
                }
            }
        }
    }

    post {
        failure {
            echo 'Deployment failed.'
        }
        success {
            echo 'Deployment succeeded!'
        }
    }
}
