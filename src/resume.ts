export { };

const levelObj: any = [
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

$('.skillDict').each(function (i: number, val: HTMLElement) {
    $(val).children('li').each(function (i: number, val: HTMLElement) {
        let itemLvl: HTMLElement = $(val).children('.skillLevel')[0];

        val.style.width = (100 * levelObj.find(e => e.name === itemLvl.innerHTML).value / 3) + "%";
    });
});