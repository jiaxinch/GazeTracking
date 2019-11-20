var app = require("express")();
var server = require("http").Server(app);
var io = require("socket.io")(server);
var edge = require("edge-js");

var EyeXFramework = edge.func("Program.cs");

var payload = {
    onGazePoint: function(data, callback) {
        io.emit("gaze", data);
        callback(null, console.log(data));
    }
};

EyeXFramework(payload, function(error, result) {
    if (error) throw error;
    console.log(result);
});

server.listen(80);

app.get("/", function(req, res) {
    res.sendfile(__dirname + "/index.html");
});
