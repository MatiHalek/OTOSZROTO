<template>
    <div class="container mx-auto">
        <div class="pt-8 flex justify-between flex-wrap mx-4 gap-2">
            <HorizontalGroup class="gap-2">
                <InputLabel for="body" class="mt-2">Liczba ofert na stronie: </InputLabel>
                <AppSelectBox style="width: min-content !important;" @selectionChanged="updateOffersPerPage" :indexSelected="offersPerPageIndex" :source="['5', '10', '20', '50']"/>
            </HorizontalGroup>
            <HorizontalGroup class="gap-2">
                <InputLabel for="body" class="mt-2">Sortuj: </InputLabel>
                <AppSelectBox @selectionChanged="(value) => { sort = value }" :indexSelected="0" :source="['Od najnowszych', 'Od najstarszych', 'Po cenie (rosnąco)', 'Po cenie (malejąco)']"/>
            </HorizontalGroup>
        </div>
        <h2 class="text-2xl font-bold text-center pt-8">Wyniki wyszukiwania dla: <span class="font-normal">{{ value.trim().toLowerCase() }}</span></h2>
        <h3 class="text-lg text-center py-2 pb-8" v-if="filteredOffers.length > 0">Pokazano stronę {{ currentPage }} z {{ pages }} (oferty: {{ (currentPage - 1) * offersPerPage + 1}}{{(Math.min(currentPage * offersPerPage, filteredOffers.length) == (((currentPage - 1) * offersPerPage) + 1)) ? "" : "-" + Math.min(currentPage * offersPerPage, filteredOffers.length)}} z {{ filteredOffers.length }})</h3>
        <h3 class="text-lg text-center py-4" v-if="filteredOffers.length === 0">Niestety, nie znaleziono wyników.</h3>

        <HorizontalGroup class="gap-4 flex-wrap justify-center">
            <AppOfferBlock v-for="(offer, index) in sortedOffers" v-show="index >= ((currentPage - 1) * offersPerPage) && index < (currentPage * offersPerPage)" :offer="offer" :key="index"/>
        </HorizontalGroup>

        <div class="flex gap-4 justify-center my-8">
            <button :class="{'block w-[40px] select-none rounded-full text-white aspect-square hover:bg-white hover:shadow-special transition-all duration-500 hover:text-[#463691]' : true, 'bg-[#E5A00A]' : page == currentPage, 'bg-[#463691]' : page != currentPage}" v-for="page in pages" v-show="Math.abs(page - currentPage) <= 3 " @click="currentPage = page">{{ page }}</button>
        </div>
    </div>
</template>

<script setup>  

const sort = ref('Od najnowszych');
const { value } = useRoute().params;
useHead({
    title: 'Wyniki wyszukiwania dla: ' + value.trim().toLowerCase() + ' | OTOSZROTO'
});
const offers = useOffersStore();   
const filteredOffers = computed(() => offers.offers.filter(item => 
    item.title.trim().toLowerCase().includes(value.trim().toLowerCase())
));

const sortedOffers = computed(() => {
    return [...filteredOffers.value].sort((a, b) => {
        switch (sort.value) {
            case 'Od najnowszych':
                return new Date(b.dateAdded) - new Date(a.dateAdded);
            case 'Od najstarszych':
                return new Date(a.dateAdded) - new Date(b.dateAdded);
            case 'Po cenie (rosnąco)':
                return a.price - b.price;
            case 'Po cenie (malejąco)':
                return b.price - a.price;
            default:
                return 0;
        }
    });
});

const offersPerPage = ref(parseInt(localStorage.getItem('offersPerPage')) || 3);
const currentPage = ref(1);
const pages = computed(() => Math.ceil(filteredOffers.value.length / offersPerPage.value));

const updateOffersPerPage = (value) => {
    offersPerPage.value = parseInt(value);
    localStorage.setItem('offersPerPage', offersPerPage.value);
    if (currentPage.value > pages.value) {
        currentPage.value = pages.value || 1;
    }
};
const offersPerPageIndex = computed(() => {
    return ['5', '10', '20', '50'].indexOf(offersPerPage.value.toString());
});


onMounted(() => {
    if (localStorage.getItem('offersPerPage')) {
        offersPerPage.value = parseInt(localStorage.getItem('offersPerPage'));
    }
});
</script>

