# Installation

1. Clone the repo from github
```
$ git clone https://github.com/danchimento/bw-code-sample
```

2. Install [Docker](https://docs.docker.com/get-docker/)
3. Install [VS Code](https://code.visualstudio.com/)
4. Install the [Remote Containers Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.vscode-remote-extensionpack)

5. Open VS Code

6. Run the task `Remote Containers: Open Folder In a Container` (CMD+Shift+P -> Run Task -> RC open folder)

7. Choose directory of the cloned repo (it will take a second to build the container)

8. Run the task `watch-api` (CMD+Shift+P -> Run Task -> watch-api)
9. Run the task `watch-app` (CMD+Shift+P -> Run Task -> watch-app)
10. Launch the following URLs to see the results
- http://localhost:5000/ExchangeRates (api)
- http://localhost:3000 (app)


<br />

# Development / Debugging
Once the API is running using the `watch-api` task, changes will automatically trigger a rebuild.

While the watch task is running, press F5 to attach the VS Code debugger.

<br />

# Notes on design

This application was approached with an MVP mindset. Only the minimum was done to ensure the requirements were met 
and the user experience was acceptable. I defined these requirements as

1. Show the exchange rate of Bitcoin using https://api.coindesk.com/v1/bpi/currentprice.json API
2. Use a React web app and a .NET 5 API
3. Ensure setup is easy for the team evaluating the code
4. BONUS: Experiment with some new tech (remote containers)