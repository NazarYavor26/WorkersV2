//Get
document.getElementById("btnRefresh").onclick = req;

window.addEventListener("DOMContentLoaded", req);

     function req() {
         const request = new XMLHttpRequest();
         request.open("GET", "api/users");
         request.setRequestHeader("Content-type", "application/json; charset=utf-8");
         request.send();
         request.addEventListener("load", function () {
             let data = JSON.parse(request.response);
             console.log(data);

             data.forEach(item => {
                 let card = document.createElement("div");

                 card.classList.add("add");

                 card.innerHTML = `
                 <div class="id">id: ${item.id}</div>
                 <div class="name">name: ${item.name}</div>
                 <div class="age">age: ${item.age}</div>
                 <hr width="200px" align="left"><br>`;

                 document.querySelector(".app").appendChild(card);
             })
         });

}



//Post
document.getElementById("btnCreate").onclick = addUser;

function addUser() {
    const request = new XMLHttpRequest();

    let person = new Object();

    person.name = document.getElementById("inputName").value;
    person.age = document.getElementById("inputAge").value;

    request.open("POST", "api/users",);

    request.responseType = "json";

    request.setRequestHeader("Content-type", "application/json; charset=utf-8");

    request.onload = () => {
        console.log(request.response);
    }

    request.send(JSON.stringify(person));
}



//PUT
document.getElementById("btnUpdate").onclick = updateUser;

function updateUser() {

    let person = {};

    person.name = document.getElementById("inputName").value;
    person.age = document.getElementById("inputAge").value;
    let id = document.getElementById("inputId").value;

    let json = JSON.stringify(person);

    const request = new XMLHttpRequest();

    request.open("PUT", "api/users/" + `${id}`);

    request.setRequestHeader('Content-type', 'application/json; charset=utf-8');
    request.onload = function () {
        console.log("put")
    }
    request.send(json);
}



//DELETE
document.getElementById("btnDelete").onclick = deleteUser;

function deleteUser() {

    let id = document.getElementById("inputId").value;

    let url = "api/users";

    const request = new XMLHttpRequest();

    request.open("DELETE", "api/users" + `/${id}`);

    request.onload = () => {
        console.log("delete");
    }

    request.send(null);
}