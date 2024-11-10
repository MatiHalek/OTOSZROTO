<template>
    <div class="container mx-auto">
        <h2 class="text-2xl font-bold text-center pt-8">Wyniki wyszukiwania dla: <span class="font-normal">{{ value }}</span></h2>
        <h3 class="text-lg text-center py-2 pb-8" v-if="filteredOffers.length > 0">Pokazano stronę {{ currentPage }} z {{ pages }} (oferty: {{ (currentPage - 1) * offersPerPage + 1}}{{(Math.min(currentPage * offersPerPage, filteredOffers.length) == (((currentPage - 1) * offersPerPage) + 1)) ? "" : "-" + Math.min(currentPage * offersPerPage, filteredOffers.length)}} z {{ filteredOffers.length }})</h3>
        <h3 class="text-lg text-center py-4" v-if="filteredOffers == 0">Niestety, nie znaleziono wyników.</h3>

        <HorizontalGroup class="gap-4 flex-wrap justify-center">
            <AppOfferBlock v-for="(offer, index) in filteredOffers" v-show="index >= ((currentPage - 1) * offersPerPage) && index < (currentPage * offersPerPage)" :offer="offer" :key="index"/>
        </HorizontalGroup>

        <div class="flex gap-4 justify-center my-8">
            <button :class="{'block w-[40px] select-none rounded-full text-white aspect-square hover:bg-white hover:shadow-special transition-all duration-500 hover:text-[#463691]' : true, 'bg-[#E5A00A]' : page == currentPage, 'bg-[#463691]' : page != currentPage}" v-for="page in pages" v-show="Math.abs(page - currentPage) <= 3 " @click="currentPage = page">{{ page }}</button>
        </div>
    </div>
</template>

<script setup>
    const { value } = useRoute().params;
    useHead({
        title: 'Wyniki wyszukiwania dla: ' + value + ' | OTOSZROTO'
    });
    const offers = useOffersStore();   
    const filteredOffers = offers.offers.filter(item => 
        item.title.toLowerCase().includes(value.toLowerCase())
    );
    const offersPerPage = 3;
    const currentPage = ref(1);
    const pages = Math.ceil(filteredOffers.length / offersPerPage); 
</script>