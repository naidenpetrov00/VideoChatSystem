﻿window.onload = function () {
	const roomId = "@Model.RoomId";
	let userId = null;
	let localStream = null;
	const peers = {};

	const connection = new signalR
		.HubConnectionBuilder()
		.withUrl("/meeting")
		.build();


	const myPeer = new Peer();
	myPeer.on('open', id => {
		const startSignalR = async () => {

			await connection.start();
			await connection.invoke("JoinRoom", roomId, id);
		}
		startSignalR();
	})

	const videoGrid = document.querySelector('#video-grid')
	const myVideo = document.createElement('video');
	myVideo.muted = true;

	navigator.mediaDevices.getUserMedia({
		audio: true,
		video: true
	}).then(stream => {
		addVideoStream(myVideo, stream);
		localStream = stream;
	})

	connection.on('user-connected', id => {
		console.log(`User connected: ${id}`)

		connectNewUser(id, localStream);
	})

	connection.on('user-disconnected', id => {
		console.log(`User disconnected: ${id}`);

		if (peers[id]) peers[id].close();
	})

	myPeer.on('call', call => {
		call.answer(localStream);

		const userVideo = document.createElement('video')
		call.on('stream', userVideoStream => {
			addVideoStream(userVideo, userVideoStream)
		})
	})

	const addVideoStream = (video, stream) => {
		video.srcObject = stream;
		video.addEventListener('loadedmetadata', () => {
			video.play()
		})
		videoGrid.appendChild(video);
	}

	const connectNewUser = (userId, localStream) => {
		const userVideo = document.createElement('video');
		const call = myPeer.call(userId, localStream)

		call.on('stream', userVideoStream => {
			addVideoStream(userVideo, userVideoStream)
		})

		call.on('close', () => {
			userVideo.remove();
		})

		peers[userId] = call;
	}
}