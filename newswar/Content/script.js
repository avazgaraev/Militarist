const bar = document.getElementById('bar');
const close = document.getElementById('close');
const nav = document.getElementById('navbar');
const indexWeapons = document.getElementById('indexWeapons');


data1 = [{
    "id": 0,
    "name": "AUG",
    "country": "USA",
    "img1": "https://qph.fs.quoracdn.net/main-qimg-247a607434a46a8cd6c18ad143c7aa2d"
}, {
    "id": 1,
    "name": "AK74",
    "country": "USSR",
    "img1": "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7f/Ak74assault.jpg/640px-Ak74assault.jpg"
}, {
    "id": 2,
    "name": "GROZA",
    "country": "Russia",
    "img1": "https://3dwarehouse.sketchup.com/warehouse/v1.0/publiccontent/9bb8f1ff-ff26-4fb9-be5a-8765cbb5b205"
}, {
    "id": 3,
    "name": "UZI",
    "country": "Israel",
    "img1": "https://upload.wikimedia.org/wikipedia/commons/thumb/8/86/Uzi_1.jpg/250px-Uzi_1.jpg"
}, {
    "id": 4,
    "name": "Cobra",
    "country": "USA",
    "img1": "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/US_Army_AH-1G_archived.jpg/300px-US_Army_AH-1G_archived.jpg"
}];

if (bar) {
    bar.addEventListener('click', () => {
        nav.classList.add('active');
    })
}

if (close) {
    close.addEventListener('click', () => {
        nav.classList.remove('active');
    })
}



// var mydata = JSON.parse(data1);
// document.getElementById("demo").innerHTML = mydata[0].name;

// function fillWeapons() {
//     var arr = [];
//     while (arr.length < 4) {
//         var r = Math.floor(Math.random() * data1.length);
//         if (arr.indexOf(r) === -1) arr.push(r);

//     }
//     // console.log(arr);
//     for (let i = 0; i < arr.length; i++) {
//         // console.log(data1[0].name);
//         var div = document.createElement("div")
//         div.classList.add('pro');
//         div.innerHTML = `

//     <div class="pro-img">
//         <img src="${data1[arr[i]]["img1"]}" alt="">

//     </div>
//     <div class="des">
//         <h5>${data1[arr[i]]["name"]}</h5>
//         <span>Silah, huecum tuefengi</span>


//         <h4>${ data1[arr[i]]["country"] }</h4>
//     </div>

//     `
//         console.log(div);
//         indexWeapons.appendChild(div);

//     }
// } 



const btn1 = document.getElementById('showNewsSearch');

var closed = true;

if (btn1) {
    btn1.addEventListener('click', () => {
        var closed=filterer.classList.contains('closed');
        if (closed) {
            btn1.innerHTML = 'paneli gizlet';
         } else {
            btn1.innerHTML = 'axtaryws  goester';
          }
        filterer.classList.toggle('closed');

    })
}