<template>
    <div class="flex flex-col items-center gap-[50px] bg-fixed bg-main-background bg-no-repeat bg-cover bg-center pb-24">
        <AppMainHeader />
        <AppSearchBlock />
        <h2 class="text-center text-3xl mt-40 font-semibold">Najnowsze ogłoszenia</h2>

        <HorizontalGroup class="gap-4 flex-wrap justify-center">
            <AppOfferBlock v-for="offer in newestOffers" :offer="offer" :key="offer.advertisementID" />
        </HorizontalGroup>
    </div>
</template>

<script setup>
    useHead({
        title: 'OTOSZROTO, czyli jazda zaczyna się tutaj | Strona główna',
    });

    const offers = useOffersStore();
    const newestOffers = ref();
    newestOffers.value = offers.offers.sort((a, b) => b.advertisementID - a.advertisementID).slice(0, 5);
</script>

<style scoped>
</style>