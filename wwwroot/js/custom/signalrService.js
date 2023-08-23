//const roomId = 

//const startSignalR = async () => {
//    const connection = new signalR
//        .HubConnectionBuilder()
//        .withUrl("/meeting")
//        .build();

//    await connection.start();

//    await connection.invoke("JoinRoom", "roomId", "10");

//    connection.on('user-connected', id => {
//        console.log(`User connected: ${id}`)
//    })
//}

//startSignalR();