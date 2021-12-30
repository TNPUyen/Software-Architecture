const URI = "https://bsite.net/projectasp/FoodService.asmx";
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
    // alert(id);
    var body = `<?xml version="1.0" encoding="utf-8"?>
    <soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
      <soap:Body>
        <GetFoodDetails xmlns="http://projectasp.org/">
          <Id>${id}</Id>
        </GetFoodDetails>
      </soap:Body>
    </soap:Envelope>`;
    axios.post(URI + "?op=GetFoodDetails", body, config).then((response) => { 
        var xmlData = response.data;
        // alert(xmlData);
        var jsonData = new X2JS ().xml_str2json(xmlData);
        // alert(JSON.stringify (jsonData));
        var data = jsonData.Envelope.Body.GetFoodDetailsResponse.GetFoodDetailsResult;
        var food = data;
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
    var body = `<?xml version="1.0" encoding="utf-8"?>
    <soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
      <soap:Body>
        <GetAll xmlns="http://projectasp.org/" />
      </soap:Body>
    </soap:Envelope>`; 
    axios.post(URI + "?op=GetAll", body, config).then((response) => { 
        var xmlData = response.data;
        // alert(xmlData); // for DEBUG
        var jsonData = new X2JS ().xml_str2json(xmlData);
        // alert(JSON.stringify (jsonData)); // for DEBUG 
        var foodlist = jsonData.Envelope.Body.GetAllResponse.GetAllResult.Food;
        // alert(JSON.stringify (foodlist)); // for DEBUG 
        renderFoodList (foodlist); 
     });  
}

function search(keyword){
    var body = `<?xml version="1.0" encoding="utf-8"?>
    <soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
      <soap:Body>
        <Search xmlns="http://projectasp.org/">
          <keyword>${keyword}</keyword>
        </Search>
      </soap:Body>
    </soap:Envelope>`;
    axios.post(URI + "?op=Search", body, config).then((response) => { 
        var xmlData = response.data;
        //alert(xmlData);
        var jsonData = new X2JS ().xml_str2json(xmlData);
        // alert(JSON.stringify (jsonData));
        var data = jsonData.Envelope.Body.SearchResponse.SearchResult.Food;
        //alert(JSON.stringify (foodlist));
        var foodlist=[];
        if(Array.isArray(data)) foodlist = data;
        else if(typeof(data) == "object") foodlist.push(data);
        renderFoodList(foodlist);
    });  
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

function addNewFood(newfood){
    var body =`<?xml version="1.0" encoding="utf-8"?>
    <soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
      <soap:Body>
        <AddNewFood xmlns="http://projectasp.org/">
          <newfood>
            <Id>${newfood.Id}</Id>
            <Name>${newfood.Name}</Name>
            <Type>${newfood.Type}</Type>
            <Description>${newfood.Description}</Description>
            <Price>${newfood.Price}</Price>
            <Amount>${newfood.Amount}</Amount>
            <Status>${newfood.Status}</Status>
          </newfood>
        </AddNewFood>
      </soap:Body>
    </soap:Envelope>`;
    axios.post(URI + "?op=AddNewFood", body, config).then((response) => {
        var xmlData = response.data;
        var jsonData = new X2JS ().xml_str2json(xmlData);
        var data = jsonData.Envelope.Body.AddNewFoodResponse.AddNewFoodResult;
        var result = JSON.parse(data);
        if (result){
            getAll();
            clearTextboxes();
        }else{
            alert('Add new food failed');
        }
    });
}

function update(newfood){
    var body = `<?xml version="1.0" encoding="utf-8"?>
    <soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
      <soap:Body>
        <UpdateFood xmlns="http://projectasp.org/">
          <food>
            <Id>${newfood.Id}</Id>
            <Name>${newfood.Name}</Name>
            <Type>${newfood.Type}</Type>
            <Description>${newfood.Description}</Description>
            <Price>${newfood.Price}</Price>
            <Amount>${newfood.Amount}</Amount>
            <Status>${newfood.Status}</Status>
          </food>
        </UpdateFood>
      </soap:Body>
    </soap:Envelope>`;
    axios.post(URI + "?op=UpdateFood", body, config).then((response) => {
        var xmlData = response.data;
        var jsonData = new X2JS ().xml_str2json(xmlData);
        var data = jsonData.Envelope.Body.UpdateFoodResponse .UpdateFoodResult;
        var result = JSON.parse(data);
        if (result){
            getAll();
            clearTextboxes();
        }else{
            alert('Update failed!!');
        }
    });
}

function deleteFood(Id){
    var body = `<?xml version="1.0" encoding="utf-8"?>
    <soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
      <soap:Body>
        <DeleteFood xmlns="http://projectasp.org/">
          <Id>${Id}</Id>
        </DeleteFood>
      </soap:Body>
    </soap:Envelope>`;
    axios.post(URI + "?op=DeleteFood", body, config).then((response) => {
        var xmlData = response.data;
        var jsonData = new X2JS ().xml_str2json(xmlData);
        var data = jsonData.Envelope.Body.DeleteFoodResponse.DeleteFoodResult;
        var result = JSON.parse(data);
        if (result){
            getAll();
            clearTextboxes();
        }else{
            alert('Delete failed!!');
        }
    });
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