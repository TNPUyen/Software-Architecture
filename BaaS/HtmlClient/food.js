const config = {
    databaseURL: "https://tnpu-8713c-default-rtdb.asia-southeast1.firebasedatabase.app/"
};
firebase.initializeApp(config);
const dbRef = firebase.database().ref();

function page_Load() {
    getAll();
}

function btnSearch_Click() {
    var keyword = document.getElementById("txtKeyword").value.trim();
    if (keyword.length > 0) {
        search(keyword);
    } else {
        getAll();
    }
}

function lnkID_Click(id) {
    getDetails(id);
}

function btnAdd_Click() {
    var newfood = {
        Id: document.getElementById("txtID").value,
        Name: document.getElementById("txtName").value,
        Type: document.getElementById("txtType").value,
        Description: document.getElementById("txtDes").value,
        Price: document.getElementById("txtPrice").value,
        Amount: document.getElementById("txtAmount").value,
        Status: document.getElementById("txtStatus").value,
    };
    addNewFood(newfood);
}

function btnUpdate_Click() {
    var newfood = {
        Id: document.getElementById("txtID").value,
        Name: document.getElementById("txtName").value,
        Type: document.getElementById("txtType").value,
        Description: document.getElementById("txtDes").value,
        Price: document.getElementById("txtPrice").value,
        Amount: document.getElementById("txtAmount").value,
        Status: document.getElementById("txtStatus").value,
    };
    updateFood(newfood);
}

function btnDelete_Click() {
    if (confirm("ARE YOU SURE?")) {
        var foodId = document.getElementById("txtID").value;
        deleteFood(foodId);
    }
}


function getAll() {
    dbRef.child('food').on('value', (snapshot) => {
        var foodList = [];
        snapshot.forEach((child) => {
            // alert(child.key); 
            var food = child.val();
            foodList.push(food);
        });
        renderFoodList(foodList);
    });
}

function search(keyword) {
    dbRef.child("food").once("value", (snapshot) => {
        var foodList = [];
        snapshot.forEach((child) => {
            var food = child.val();
            if (food.Name.toLowerCase().includes(keyword.toLowerCase())) {
                foodList.push(food);
            }
        });
        renderFoodList(foodList);
    });
}

function getDetails(id) {
    dbRef.child("food").once("value", (snapshot) => {
        snapshot.forEach((child) => {
            var food = child.val();
            if (food.Id == id) {
                renderFoodDetails(food);
            }
        });
    });
}


function addNewFood(newfood) {
    // dbRef.child('food').push(newfood);
    dbRef.child("food/F" + newfood.Id).set(newfood);
}

function updateFood(newfood) {
    dbRef.child("food").once("value", (snapshot) => {
        snapshot.forEach((child) => {
            var food = child.val();
            if (food.Id == newfood.Id) {
                var key = child.key;
                dbRef.child("food").child(key).set(newfood);
            }
        });
    });
}

function deleteFood(Id) {
    dbRef.child("food").once("value", (snapshot) => {
        snapshot.forEach((child) => {
            var food = child.val();
            if (food.Id == Id) {
                var key = child.key;
                dbRef.child("food").child(key).remove();
            }
        });
    });
}

function renderFoodList(foodlist) {
    var rows = "";
    for (var food of foodlist) {
        rows += "<tr onclick='lnkID_Click(" + food.Id + ")' style='cursor:pointer'>";
        rows += "<td>" + food.Id + "</td>";
        rows += "<td>" + food.Name + "</td>";
        rows += "<td>" + food.Type + "</td>";
        rows += "<td>" + food.Description + "</td>";
        rows += "<td>" + food.Price + "</td>";
        rows += "<td>" + food.Amount + "</td>";
        rows += "<td>" + food.Status + "</td>";
        rows += "</td>";
    }
    var header = "<tr><th>ID</th><th>Name</th><th>Type</th><th>Description</th><th>Price</th><th>Amount</th><th>Status</th></tr>";
    document.getElementById("foodlist").innerHTML = header + rows;
}

function renderFoodDetails(food) {
    document.getElementById("txtID").value = food.Id;
    document.getElementById("txtName").value = food.Name;
    document.getElementById("txtType").value = food.Type;
    document.getElementById("txtDes").value = food.Description;
    document.getElementById("txtPrice").value = food.Price;
    document.getElementById("txtAmount").value = food.Amount;
    document.getElementById("txtStatus").value = food.Status;
}

function clearTextboxes() {
    document.getElementById("txtID").value = '';
    document.getElementById("txtName").value = '';
    document.getElementById("txtType").value = '';
    document.getElementById("txtDes").value = '';
    document.getElementById("txtPrice").value = '';
    document.getElementById("txtAmount").value = '';
    document.getElementById("txtStatus").value = '';
}