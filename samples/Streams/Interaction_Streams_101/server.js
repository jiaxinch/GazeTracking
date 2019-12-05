var net = require("net");

var app = require("express")();
var http = require("http").createServer(app);
var io = require("socket.io")(http);

//net
var server = net.createServer(function(connection) {
    console.log("client connected");

    connection.on("end", function() {
        console.log("client disconnected");
    });

    connection.on("data", function(data) {
        console.log(data.toString());
        io.emit("data", data.toString());
    });

    connection.on("error", err => {
        console.error(err);
    });

    connection.write("Hello World!\r\n");
    //io.emit('data', "another gaze cooridiate")
    connection.pipe(connection);
});

server.listen(3001, function() {
    console.log("server is listening");
});
//net end

//socket io
// app.get("/", function(req, res) {
//     res.sendFile(__dirname + "/index.html");
// });

io.on("connection", function(socket) {
    console.log("a socket io user connected");
    //io.emit("data", "a gaze cooridiate");
});

io.on("disconnected", function(socket) {
    console.log("a socket io user disconnected");
    //io.emit("data", "a gaze cooridiate");
});

http.listen(3000, function() {
    console.log("listening on *:3000");
});
//socket io
