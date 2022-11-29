/*! For license information please see resume.bundle.js.LICENSE.txt */
var MYAPP;(()=>{"use strict";var __webpack_modules__={"./src/resume.ts":(__unused_webpack_module,__webpack_exports__,__webpack_require__)=>{eval('__webpack_require__.r(__webpack_exports__);\nvar levelObj = [\r\n    {\r\n        name: "Beginner",\r\n        value: 1\r\n    },\r\n    {\r\n        name: "Intermediate",\r\n        value: 2\r\n    },\r\n    {\r\n        name: "Advanced",\r\n        value: 3\r\n    }\r\n];\r\n$(\'.skillDict\').each(function (i, val) {\r\n    $(val).children(\'li\').each(function (i, val) {\r\n        var itemLvl = $(val).children(\'.skillLevel\')[0];\r\n        val.style.width = (100 * levelObj.find(function (e) { return e.name === itemLvl.innerHTML; }).value / 3) + "%";\r\n    });\r\n});\r\n\r\n\n\n//# sourceURL=webpack://MYAPP/./src/resume.ts?')}},__webpack_require__={r:e=>{"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})}},__webpack_exports__={};__webpack_modules__["./src/resume.ts"](0,__webpack_exports__,__webpack_require__),MYAPP=__webpack_exports__})();