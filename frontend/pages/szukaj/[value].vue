<template>
    <div class="container mx-auto">
        <h2 class="text-2xl text-center py-8">Wyniki wyszukiwania dla: {{ value }} ({{ filteredOffers.length }})</h2>

        <HorizontalGroup class="gap-4 flex-wrap justify-center">
            <AppOfferBlock v-for="offer in filteredOffers" :offer="offer"/>
        </HorizontalGroup>
    </div>
</template>

<script setup>
    const offers = useOffersStore();

    const { value } = useRoute().params;
    const filteredOffers = offers.offers.filter(item => 
        item.title.toLowerCase().includes(value.toLowerCase())
    );
</script>