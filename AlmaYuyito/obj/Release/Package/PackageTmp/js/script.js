/* Set the width of the sidebar to 250px and the left margin of the page content to 250px */
function openNav() {
	var element = document.getElementById("nav-lateral");

	if(element.style.display === "none" ){
		element.style.display = "block";
	}else{
		element.style.display = "none";
	}
	
}

function semiColapsar() {
	var element = document.getElementById("nav-lateral");
	var contenido = document.getElementById("contenido");
    var icFlecha = document.getElementById("icono-flecha");
    var menuParrafos = document.getElementsByClassName("item-menu-text");
    var menuIconos = document.getElementsByClassName("item-menu-icon");
    var i;
    
    if (element.style.width === "4rem") {

        if (screen.width > 799 && screen.width < 1001) {
            element.style.width = "30%";
        } else {
            element.style.width = "15rem";
        }
		contenido.style.width = "100%";
        icFlecha.classList.add("invertir");
        for (i = 0; i < menuParrafos.length; i++) {
            menuParrafos[i].classList.remove('hidden');
        } 

        for (i = 0; i < menuIconos.length; i++) {
            menuIconos[i].classList.remove('icon-semi-collapse');
        } 
        
	}else{
		element.style.width = "4rem";
		contenido.style.width = "100%";
        icFlecha.classList.remove("invertir");
        for (i = 0; i < menuParrafos.length; i++) {
            menuParrafos[i].classList.add('hidden');
        } 

        for (i = 0; i < menuIconos.length; i++) {
            menuIconos[i].classList.add('icon-semi-collapse');
        } 
	}
	
}

/* Set the width of the sidebar to 0 and the left margin of the page content to 0 */
function closeNav() {
  	var element = document.getElementById("nav-lateral");


  	if(element.style.display === 'none' ){
		element.classList.add("nav-abierto");
	}

}

function prueba(){
	var element = $('#nav-lateral');

    var contenido = $('#contenido');

    var icFlecha = $("icono-flecha");

    if (element.width === "5%") {
        element.width = "20%";
        contenido.width = "100%";
        icFlecha.toggleClass("invertir");
    } else {
        element.width = "5%";
        contenido.width = "95%";
        icFlecha.toggleClass("invertir");
    }
}



function mostrarSubmenu(id) {


    document.getElementById(id).classList.toggle("show");
    document.getElementById(id).classList.toggle("v-zero");
    document.getElementById(id).classList.toggle("v-visible");
}

// Close the dropdown menu if the user clicks outside of it
window.onclick = function (event) {
    if (!event.target.matches('.sub-menu')) {
        var dropdowns = document.getElementsByClassName("dropdown-content");
        var i;
        for (i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show')) {
                openDropdown.classList.remove('show');
            }
        }
    }
}