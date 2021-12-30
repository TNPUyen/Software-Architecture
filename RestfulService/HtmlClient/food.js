const URL = "http://tnpu.somee.com/api/food";
const config = { headers : { 'Content-Type': 'text/xml' } };

function page_Load(){
    getAll();
}

function btnSearch_Click(){
    var keyword = document.getElementById("txtKeyword").value.trim();
    if(keyword.length > 0){
        search(keyword);
    }else{
        getAll();
    }
}

function lnkID_Click(id){
    axios.get(URL + "/" + id).then((response) => { 
        var food = response.data;
        renderFoodDetails(food);
    });   
}

function btnAdd_Click(){
    var newfood = {
        Id:0,
        Name: document.getElementById("txtName").value,
        Type: document.getElementById("txtType").value,
        Description: document.getElementById("txtDes").value,
        Price: document.getElementById("txtPrice").value,
        Amount: document.getElementById("txtAmount").value,
        Status: document.getElementById("txtStatus").value,
    };
    addNewFood(newfood);
}

function btnUpdate_Click(){
    var newfood = {
        Id:document.getElementById("txtID").value,
        Name: document.getElementById("txtName").value,
        Type: document.getElementById("txtType").value,
        Description: document.getElementById("txtDes").value,
        Price: document.getElementById("txtPrice").value,
        Amount: document.getElementById("txtAmount").value,
        Status: document.getElementById("txtStatus").value,
    };
    update(newfood);
}

function btnDelete_Click(){
    if(confirm("ARE YOU SURE?")){
        var foodId = document.getElementById("txtID").value;
        deleteFood(foodId);
    }
}


function getAll(){
    axios.get(URL).then((response) => {
        var foodlist = response.data;
        renderFoodList(foodlist);
    })
}

function search(keyword){
    axios.get(URL + "/search/" + keyword).then((response) => {
        var foodlist = response.data;
        renderFoodList(foodlist);
    })
}


function addNewFood(newfood){
    axios.post(URL, newfood).then((response) => {
        var result = response.data;
        if(result){
            getAll();
            clearTextboxes();
        }else{
            alert("Add new food failed");
        }
    })
}

function update(newfood){
    axios.put(URL + "/" + newfood.Id, newfood).then((response) => {
        var result = response.data;
        if(result){
            getAll();
            clearTextboxes();
        }else{
            alert("Update food failed");
        }
    })
}

function deleteFood(Id){
    axios.delete(URL + "/" + Id).then((response) => {
        var result = response.data;
        if(result){
            getAll();
            clearTextboxes();
        }else{
            alert("Delete food failed");
        }
    })
}

function renderFoodList(foodlist){
    var rows = "";
    for(var food of foodlist){
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

function renderFoodDetails(food){
    document.getElementById("txtID").value = food.Id;
    document.getElementById("txtName").value = food.Name;
    document.getElementById("txtType").value = food.Type;
    document.getElementById("txtDes").value = food.Description;
    document.getElementById("txtPrice").value = food.Price;
    document.getElementById("txtAmount").value = food.Amount;
    document.getElementById("txtStatus").value = food.Status;
}

function clearTextboxes(){
    document.getElementById("txtID").value = '';
    document.getElementById("txtName").value = '';
    document.getElementById("txtType").value = '';
    document.getElementById("txtDes").value = '';
    document.getElementById("txtPrice").value = '';
    document.getElementById("txtAmount").value = '';
    document.getElementById("txtStatus").value = '';
}