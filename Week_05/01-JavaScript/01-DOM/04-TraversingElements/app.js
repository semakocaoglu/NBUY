let sonuc;
// let taskList = document.getElementById('task-list');
// sonuc = taskList.children;
// sonuc = taskList.children[0];
// sonuc = taskList.firstElementChild.innerText;
// sonuc = taskList.lastElementChild.innerText;

// sonuc = document.getElementById('title');
// sonuc = sonuc.parentElement.parentElement.parentElement;

// taskList = document.querySelector('.task');
// sonuc = taskList.nextElementSibling.nextElementSibling;
// sonuc = sonuc.previousElementSibling;
let ul = document.getElementById('task-list');
sonuc = ul.children;
sonuc = ul.children[0].children[0].children[0].checked=true;

console.log(sonuc);