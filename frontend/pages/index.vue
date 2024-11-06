<template>
    <div class="mt-20 flex flex-col items-center gap-[50px]">
        <AppMainHeader />
        <AppSearchBlock />
        <h2 class="text-center text-3xl mt-40 font-semibold">Najnowsze ogłoszenia</h2>

        <HorizontalGroup class="gap-4">
            <AppOfferBlock v-for="i in 5" />
        </HorizontalGroup>
    </div>
</template>

<script setup>
    useHead({
        title: 'OTOSZROTO, czyli jazda zaczyna się tutaj | Strona główna',
    });
</script>

<style scoped>
</style>