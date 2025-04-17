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
                    bat 'docker-compose down'
                    bat 'docker-compose build'
                    bat 'docker-compose up -d'
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
