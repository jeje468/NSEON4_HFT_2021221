let phones = [];
let connection;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:62814/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("PhoneCreated", (user, message) => {
        getdata();
    });

    connection.on("PhoneDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:62814/phone')
        .then(x => x.json())
        .then(y => {
            phones = y;
            console.log(phones);
            display();
        });
}




function display() {
    document.getElementById('resultarea').innerHTML = "";
    phones.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>"
            + t.price + "</td><td>"
            + t.cameraPixels + "</td><td>"
            + t.brandId + "</td><td>"
            + `<button type="button" onclick="remove(${t.id})">Delete</button>`
            + "</td></tr>";
    })
}

function remove(id) {
    fetch('http://localhost:62814/phone/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let name = document.getElementById('name').value;
    let price = document.getElementById('price').value;
    let cameraPixels = document.getElementById('cameraPixels').value;
    let brandId = document.getElementById('brandId').value;

    fetch('http://localhost:62814/phone', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name, price: price, cameraPixels: cameraPixels, brandId: brandId })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function update() {
    let name = document.getElementById('name').value;
    let price = document.getElementById('price').value;
    let cameraPixels = document.getElementById('cameraPixels').value;
    let brandId = document.getElementById('brandId').value;
    let id = document.getElementById('id').value;

    fetch('http://localhost:62814/phone', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {id: id, name: name, price: price, cameraPixels: cameraPixels, brandId: brandId })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}