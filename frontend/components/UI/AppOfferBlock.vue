<template>
    <NuxtLink :to="'/ogloszenie/' + offer.advertisementID" class="hover:translate-y-[-8px] transition-all duration-500">
        <div class="w-80 aspect-square rounded-lg shadow-lg">
            <img src="https://getwallpapers.com/wallpaper/full/1/c/a/772763-windows-vista-desktop-background-1920x1440-smartphone.jpg" alt="Zdjęcie oferty" class="object-cover rounded-t-lg w-full h-2/4">
            <div class="p-3 flex flex-col h-2/4">
                <p :title="offer.title" class="font-bold text-lg text-ellipsis overflow-hidden w-[calc(100%)] whitespace-nowrap">{{ offer.title }}</p>
                <hr class="bg-black my-3">
                <p class="text-gray-500">{{ offer.condition }} • {{ offer.yearOfProduction }}</p>
                <p class="text-center text-2xl drop-shadow-lg font-bold text-white mix-blend-darken bg-gradient-to-br from-[#463691CC] from-40% to-[#E5A00ACC] mx-auto px-6 py-2 rounded-full mt-3">
                    <i class="fa-solid fa-sack-dollar me-2"></i>{{ offer.price }} PLN           
                </p>
            </div>            
        </div>
    </NuxtLink>
</template>

<script setup>
    defineProps(['offer'])
</script>