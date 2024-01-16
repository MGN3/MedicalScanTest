let doctors = [];

async function specialtyQuery(specialization = "all") {
	try {
		const apiUrl = 'https://localhost:7202/Byspecialization';

		const response = await fetch(`${apiUrl}?specialization=${encodeURIComponent(specialization)}`);

		if (!response.ok) {
			throw new Error(`HTTP error! Status: ${response.status}`);
		}

		const data = await response.json();
		console.log(data);

		doctors = [];

		// Iterating through every object.
		data.forEach(doctorData => {
			const doctor = {
				doctorId: doctorData.doctorId,
				doctorName: doctorData.doctorName,
				specialties: doctorData.specialties
			};
			doctors.push(doctor);
		});

		createDoctorCards(doctors);

		console.log(doctors);

	} catch (error) {

		console.error('Fetch error:', error);
	}
}

specialtyQuery();

function createDoctorCards(doctors) {
	const doctorsContainer = document.getElementById('doctorsContainer');

	while (doctorsContainer.firstChild) {
		doctorsContainer.removeChild(doctorsContainer.firstChild);
	}
	for (const doctor of doctors) {
		const card = document.createElement('div');
		card.classList.add('col-md-6', 'col-lg-3', 'd-flex', 'align-items-stretch', 'mb-5', 'mb-lg-0');

		const iconBox = document.createElement('div');
		iconBox.classList.add('icon-box');
		iconBox.setAttribute('data-aos', 'fade-up');
		iconBox.setAttribute('data-aos-delay', '100');

		const icon = document.createElement('div');
		icon.classList.add('icon');
		// Add icon or SVG

		const doctorName = document.createElement("h4");
		doctorName.setAttribute("id", `doctor${doctor.doctorId}`)
		doctorName.innerText = `${doctor.doctorName}`

		const doctorSpecialties = document.createElement('ul');
		doctorSpecialties.setAttribute('id', 'doctorSpecialties');

		doctor.specialties.forEach(specialty => {
			const specialtyElement = document.createElement("li");
			specialtyElement.id = "specialty";
			specialtyElement.textContent = specialty;

			doctorSpecialties.appendChild(specialtyElement);
		});

		iconBox.appendChild(icon);
		iconBox.appendChild(doctorName);
		iconBox.appendChild(doctorSpecialties);

		card.appendChild(iconBox);

		doctorsContainer.appendChild(card);
	}
}


/*<div     <section id="featured-services" class="featured-services">
	  <div class="container" data-aos="fade-up">

		<div id="doctorsContainer" class="row">

		  <div class="col-md-6 col-lg-3 d-flex align-items-stretch mb-5 mb-lg-0">
			<div class="icon-box" data-aos="fade-up" data-aos-delay="100">
			  <div class="icon">
				<!-- Reemplaza el ícono predefinido con el código SVG -->
				<svg b-ge2kwu6o28="" class="svg-inline--fa fa-user-doctor" aria-hidden="true" focusable="false"
				  data-prefix="fas" data-icon="user-doctor" role="img" xmlns="http://www.w3.org/2000/svg"
				  viewBox="0 0 448 512" data-fa-i2svg="">
				  <path fill="currentColor"
					d="M224 256A128 128 0 1 0 224 0a128 128 0 1 0 0 256zm-96 55.2C54 332.9 0 401.3 0 482.3C0 498.7 13.3 512 29.7 512H418.3c16.4 0 29.7-13.3 29.7-29.7c0-81-54-149.4-128-171.1V362c27.6 7.1 48 32.2 48 62v40c0 8.8-7.2 16-16 16H336c-8.8 0-16-7.2-16-16s7.2-16 16-16V424c0-17.7-14.3-32-32-32s-32 14.3-32 32v24c8.8 0 16 7.2 16 16s-7.2 16-16 16H256c-8.8 0-16-7.2-16-16V424c0-29.8 20.4-54.9 48-62V304.9c-6-.6-12.1-.9-18.3-.9H178.3c-6.2 0-12.3 .3-18.3 .9v65.4c23.1 6.9 40 28.3 40 53.7c0 30.9-25.1 56-56 56s-56-25.1-56-56c0-25.4 16.9-46.8 40-53.7V311.2zM144 448a24 24 0 1 0 0-48 24 24 0 1 0 0 48z">
				  </path>
				</svg>
			  </div>
			  <h4 id="doctorName">
					Dr. Gipsz Jakab
			</h4>
			  <ul id="doctorSpecialties">
				<li id="specialty">Belgyógyász</li>
				<li id="specialty">Reumatológus</li>
				<li id="specialty">Onkológus</li>
			  </ul>
			</div>
		  </div>*/
// function createDoctorsCards(doctors) {
// 	const cardsContainer = document.getElementById("doctorsContainer");
// 	for (doctor of doctors) {
// 		const mainDiv = document.createElement("div");
// 		firstDiv.classList.add("col-md-6 col-lg-3 d-flex align-items-stretch mb-5 mb-lg-0");

// 		const iconBox = document.createElement("div");
// 		iconDiv.classList.add("icon-box");
// 		iconDiv.setAttribute("data-aos", "fade-up")
// 		iconDiv.setAttribute("data-aos-delay", "100")

// 		const iconDiv = document.createElement("div");
// 		iconDiv.classList.add("icon")

// 		const iconSvg = document.createElement("svg");
// 		iconSvg.setAttribute("b-ge2kwu6o28", "");
// 		iconSvg.classList.add("svg-inline--fa", "fa-user-doctor");
// 		iconSvg.setAttribute("aria-hidden", "true");
// 		iconSvg.setAttribute("focusable", "false");
// 		iconSvg.setAttribute("data-prefix", "fas");
// 		iconSvg.setAttribute("data-icon", "user-doctor");
// 		iconSvg.setAttribute("role", "img");
// 		iconSvg.setAttribute("xmlns", "http://www.w3.org/2000/svg");
// 		iconSvg.setAttribute("viewBox", "0 0 448 512");
// 		iconSvg.setAttribute("data-fa-i2svg", "");

// 		const pathElement = document.createElement("path");
// 		pathElement.setAttribute("fill", "currentColor");
// 		pathElement.setAttribute("d", "M224 256A128 128 0 1 0 224 0a128 128 0 1 0 0 256zm-96 55.2C54 332.9 0 401.3 0 482.3C0 498.7 13.3 512 29.7 512H418.3c16.4 0 29.7-13.3 29.7-29.7c0-81-54-149.4-128-171.1V362c27.6 7.1 48 32.2 48 62v40c0 8.8-7.2 16-16 16H336c-8.8 0-16-7.2-16-16s7.2-16 16-16V424c0-17.7-14.3-32-32-32s-32 14.3-32 32v24c8.8 0 16 7.2 16 16s-7.2 16-16 16H256c-8.8 0-16-7.2-16-16V424c0-29.8 20.4-54.9 48-62V304.9c-6-.6-12.1-.9-18.3-.9H178.3c-6.2 0-12.3 .3-18.3 .9v65.4c23.1 6.9 40 28.3 40 53.7c0 30.9-25.1 56-56 56s-56-25.1-56-56c0-25.4 16.9-46.8 40-53.7V311.2zM144 448a24 24 0 1 0 0-48 24 24 0 1 0 0 48z");

// 		const doctorName = document.createElement("h4");
// 		doctorName.setAttribute("id", `doctor${doctor.doctorId}]`)
// 		doctorName.innerText(`${doctor.doctorName}`)

// 		const specialties = document.createElement("ul");
// 		specialties.setAttribute("id", "doctorSpecialties")

// 		doctor.specialties.forEach(specialty => {
// 			const specialtyElement = document.createElement("li");
// 			specialtyElement.id = "specialty";
// 			specialtyElement.textContent = specialty;

// 			doctorSpecialties.appendChild(specialtyElement);
// 		});



// 	}
// }

// function createSpecialtiesList(doctor){
// 	doctor.specialties.forEach(specialty => {
// 		const specialtyElement = document.createElement("li");
// 		specialtyElement.id = "specialty";
// 		specialtyElement.textContent = specialty;

// 		doctorSpecialties.appendChild(specialtyElement);
// 	});
// }


// function createProductCards(productList) {
// 	// Main container to enclose the rest of elements, CHECK
// 	const container = document.getElementById("container");

// 	for (product of productList) {
// 		const cardsContainer = document.querySelector(".cards-container");

// 		const productCard = document.createElement("div");
// 		productCard.classList.add("product-card");
// 		productCard.setAttribute("category", product.category);

// 		const productImg = document.createElement("img");
// 		productImg.setAttribute("src", product.urlImg);
// 		productImg.setAttribute("alt", "Ups, error loading product image.");
// 		productImg.setAttribute("id", product.id);

// 		const productData = document.createElement("div");
// 		productData.classList.add("product-info");

// 		const productDataChild = document.createElement("div");

// 		const productPrice = document.createElement("p");
// 		productPrice.textContent = "$" + product.price;

// 		const productName = document.createElement("p");
// 		productName.innerText = product.name;

// 		const productIconFigure = document.createElement("figure");
// 		const productIconImg = document.createElement("img");
// 		productIconImg.setAttribute("src", "./icons/bt_add_to_cart.svg");
// 		productIconImg.setAttribute("onclick", "addToCart(" + product.id + ")");
// 		productIconImg.setAttribute("alt", "Cart Icon");

// 		productData.append(productDataChild, productIconFigure);
// 		productDataChild.append(productPrice, productName);
// 		productIconFigure.append(productIconImg);
// 		productCard.append(productImg, productData);
// 		cardsContainer.append(productCard);

// 		productImg.addEventListener("click", () => {
// 			const overlayId = document.querySelector("#overlay" + productImg.id);
// 			overlayId.classList.remove("inactive");
// 		});
// 	}
// }