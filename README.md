This repository is a tool that can show the coordinate of Tobii gaze tracker to a website using Tobii CoreSDK in .Net and node.js

#How to make it work
You need to install Visual Studio, node.js, express and socket.io. 

```
npm install express
npm install socket.io
```

1. Run the node.js server at
Go to samples/Streams/Interaction_Streams_101/ at terminal 
```
node server.js 
```

2. Run C# SDK code
Make sure the gaze tracker is plugged in
Open up Tobii.CoreSDK.Samples.sln at /samples
Run program in Interaction_Streams_101
You can now see the coordinate at Visual Studio terminal and node.js server terminal 

3. Go to localhost:3000 at you browser 
Now you should see the coordinate shown at console of browser! 

Feel free to edit server.js and index.html to implmenent more feature. 
