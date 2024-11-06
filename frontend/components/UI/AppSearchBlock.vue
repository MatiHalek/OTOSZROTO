<template>
    <div class="w-full sm:w-[90%] h-fit shadow-[0px_0px_70px_-62px_rgba(66,68,90,1)] bg-white p-10">
        <VerticalGroup class="gap-3">
            <AppPlaceholderInput placeholder="Wyszukaj..."/>

            <HorizontalGroup class="gap-3 flex-col sm:flex-row">
                <AppPlaceholderInput placeholder="Cena"/>
                <AppPlaceholderInput placeholder="Rocznik"/>
            </HorizontalGroup>

            <div class="mt-24 flex flex-col sm:flex-row gap-5 sm:gap-0 justify-between items-center">
                <p class="text-[#463691] font-semibold text-base">Wyszukiwanie zaawansowane</p>
                <button class="self-end bg-[#E5A00A] text-white p-2 border w-full sm:w-40 rounded-full hover:shadow-special hover:bg-transparent hover:text-[#463691] transition-all duration-300">Szukaj</button>
            </div>
        </VerticalGroup>
    </div>
</template>

<script setup>

</script>