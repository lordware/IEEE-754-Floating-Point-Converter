let text1 = document.querySelector('.jss250').textContent;
let text2 = document.querySelector('.jss245.jss246').textContent;
let text3 = document.querySelector('.jss245.jss247').textContent;
let text4 = document.querySelector('.jss245.jss248').textContent;
let text5 = document.querySelector('.jss245.jss249').textContent;

let words = [text2, text3, text4, text5];
let wordCounts = [0, 0, 0, 0];
let url = `https://www.google.com/search?q=${text1}`;
let proxy = "https://corsproxy.io/?"

let dict = {
    0: ".jss32.jss33",
    1: ".jss32.jss34",
    2: ".jss32.jss35",
    3: ".jss32.jss36"
};

fetch(proxy + url)
.then(response => response.text())
.then(data => {
    for(let i = 0; i < words.length; i++) {
        wordCounts[i] = data.split(words[i]).length - 1;
    }
    console.log(wordCounts);
    let max = Math.max(...wordCounts);
    let index = wordCounts.indexOf(max);
    let elem = document.querySelector(dict[index])
    elem.click();
})
.catch(error => console.error('Error:', error));
