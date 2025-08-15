function hide(){
    let w = window.innerWidth;
    let c1 = document.getElementById("center");
    let c2 = document.getElementById("search");
    let c3 = document.getElementById("left_sec")
    let c4 = document.getElementById("right_sec")

    if (w < 1150){
        c3.style.display = "none";
        c4.style.display = "none";
    } else {
        c3.style.display = "flex";
        c4.style.display = "flex";
    }

    if (w < 1000){
        c1.style.display = "none";
    } else {
        c1.style.display = "flex";
    }

    if (w < 500){
        c2.style.display = "none";
    } else {
        c2.style.display = "flex";
    }
}

function password(n) {
    let espacio = document.getElementById("password" + n);
    let boton = document.getElementById("eye" + n);
    if (espacio.type == "password") {
        espacio.type = "text";
        boton.style.backgroundImage = "url('../images/closeeye.png')";
    } else {
        espacio.type = "password";
        boton.style.backgroundImage = "url('../images/eye.png')";
    }
}

window.addEventListener("resize", hide);
document.addEventListener("DOMContentLoaded", hide);

