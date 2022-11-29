import * as THREE from 'three';
import { RoundedBoxGeometry } from 'three/examples/jsm/geometries/RoundedBoxGeometry';
import { OrbitControls } from 'three/examples/jsm/controls/OrbitControls';
//import Stats from 'three/examples/jsm/libs/stats.module';
//import { GUI } from 'dat.gui';

// get canvas to show 3d
const canvas: HTMLElement = $('#home-3d-viewport')[0];

// initiate scene & camera
const scene = new THREE.Scene();
const camera = new THREE.PerspectiveCamera(75, canvas.clientWidth / canvas.clientHeight, 0.1, 1000);

// set up 3d renderer
const renderer = new THREE.WebGLRenderer({ alpha: true });
renderer.setSize(canvas.clientWidth, canvas.clientHeight);
canvas.appendChild(renderer.domElement);

// create and add geometry to scene
const geometry = new RoundedBoxGeometry(10, 10, 10, 2, 2);
const material = new THREE.MeshLambertMaterial({ color: 0xffffff });
const cube = new THREE.Mesh(geometry, material);
scene.add(cube);

// add spotlight for lambert material to work
const spotlight = new THREE.SpotLight(0xffffff);
spotlight.position.set(0, 0, 300);
scene.add(spotlight);

/*const axesHelper = new THREE.AxesHelper(100);
scene.add(axesHelper);*/

camera.position.z = 20;
camera.lookAt(0, 0, 0);

renderer.render(scene, camera);

// enable orbit control by user
const controls = new OrbitControls(camera, renderer.domElement);
controls.maxDistance = 100;
controls.minDistance = 15;
controls.addEventListener('change', function () {
	renderer.render(scene, camera);
});

// show performance stats
/*const stats = Stats();
document.body.appendChild(stats.dom);*/

// create param control panel
/*const gui = new GUI();
const cameraFolder = gui.addFolder('Camera');
cameraFolder.add(camera.position, 'x', 0, 100);
cameraFolder.add(camera.position, 'y', 0, 100);
cameraFolder.add(camera.position, 'z', 0, 100);
cameraFolder.open()
const spotlightFolder = gui.addFolder('spotlight');
spotlightFolder.add(spotlight.position, 'x', 0, 1000);
spotlightFolder.add(spotlight.position, 'y', 0, 1000);
spotlightFolder.add(spotlight.position, 'z', 0, 1000);
spotlightFolder.open();*/

function animate() {
	requestAnimationFrame(animate);
	renderer.render(scene, camera);

	cube.rotation.x += 0.01;
	cube.rotation.y += 0.01;
	cube.rotation.z += 0.01;

	renderer.render(scene, camera);

	//stats.update();
}

animate();

// change renderer size & camera aspect once window resize is complete
var resizeTimer;
$(window).on('resize', function (e) {

	clearTimeout(resizeTimer);
	resizeTimer = setTimeout(function () {

		// Run code here, resizing has "stopped"

		renderer.setSize(canvas.clientWidth, canvas.clientHeight);

		camera.aspect = canvas.clientWidth / canvas.clientHeight;
		camera.updateProjectionMatrix();

	}, 250);

});