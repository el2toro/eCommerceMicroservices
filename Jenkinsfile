pipeline {
    agent any

    stages {

        stage('Build & Deploy with Docker Compose') {
            steps {
                script {
                    sh 'docker-compose down'
                    sh 'docker-compose build'
                    sh 'docker-compose up -d'
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
