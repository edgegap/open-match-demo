### Table of Contents

<!-- TABLE OF CONTENTS -->
* [About The Project](#about-the-project)
* [Getting Started](#getting-started)
    * [Prerequisites](#prerequisites)
    * [Installation](#installation)
* [License](#license)



<!-- ABOUT THE PROJECT -->
## About The Project

This is the source code associated with [this](https://docs.edgegap.com/docs/openmatch/tutorials/basic/open-match-tutorial-basics-introduction) tutorial.



<!-- GETTING STARTED -->
## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

* [Install](https://golang.org/dl/) Golang on your computer
* Install [Docker](https://docs.docker.com/docker-for-windows/install/)
* Having a Kubernetes ecosystem available _([Docker Desktop includes a standalone Kubernetes server and client](https://docs.docker.com/docker-for-windows/kubernetes/))_
* Change the variables in ***.\director\main.go***
    * gameServerPort
    * appName
    * appVersion
    * arbitriumAPI
    * apiToken

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/edgegap/open-match.git
   ```
2. Go to the tutorial's folder
   ```sh
   cd [PATH_TO_PROJECT]/tutorials/basic-components
   ```
3. In ***./director/main.go*** change the variables to put your values.
    ```go
    // Game server data
    gameServerPort = "<APP_PORT>"      // String | E.G. 25565
    appName        = "<APP_NAME>"      // E.G. MySuperGame
    appVersion     = "<APP_VERSION>"   // E.G. V1
    arbitriumAPI   = "<ARBITRIUM_API>" // E.G. https://staging-api.edgegap.com/
    apiToken       = "<API_TOKEN>"     // E.G. 1111aa11aa11111a1aa11111d111a111111111a1
    ```
4. Install using the appropriate script

    **Windows (Powershell)**
    ```sh
    install.ps1
    ```

    **Windows (CMD)**
    ```sh
    install.bat
    ```

5. You can delete it using the appropriate script

    **Windows (Powershell)**
    ```ps1
    delete.ps1
    ```

    **Windows (CMD)**
    ```ps1
    delete.bat
    ```


## Acknowledgements
* [Open Match](https://openmatch.dev/site/docs/guides/)