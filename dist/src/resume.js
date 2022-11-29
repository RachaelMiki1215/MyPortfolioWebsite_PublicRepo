var levelObj = [
    {
        name: "Beginner",
        value: 1
    },
    {
        name: "Intermediate",
        value: 2
    },
    {
        name: "Advanced",
        value: 3
    }
];
$('.skillDict').each(function (i, val) {
    $(val).children('li').each(function (i, val) {
        var itemLvl = $(val).children('.skillLevel')[0];
        val.style.width = (100 * levelObj.find(function (e) { return e.name === itemLvl.innerHTML; }).value / 3) + "%";
    });
});
export {};
//# sourceMappingURL=resume.js.map