<template>
    <NuxtLink :to="'/ogloszenie/' + offer.advertisementID" class="hover:translate-y-[-8px] transition-all duration-500 bg-white dark:bg-[#334155] rounded-md">
        <div class="w-80 relative aspect-square rounded-lg shadow-lg hover:shadow-special transition-all duration-500">
            <div class="absolute top-0 bg-[#0F0] px-3 py-1 bg-[#463691] shadow-md text-sm font-semibold translate-y-[-30%] right-5 text-white rounded-full"><i class="fa-solid fa-calendar-day me-2 "></i>{{ new Intl.DateTimeFormat('pl-PL', { day: 'numeric', month: 'short', year: 'numeric' }).format(new Date(offer.dateAdded))}}</div>
            <img v-if="image[0]" :src="'http://localhost:5271/api/Uploads/gallery/' + image[0].imageSource" alt="Zdjęcie oferty" class="object-cover rounded-t-lg w-full h-2/4">
            <img v-else alt="Zdjęcie oferty" class="object-cover rounded-t-lg w-full h-2/4">
            <div class="p-3 flex flex-col h-2/4">
                <p :title="offer.title" class="font-bold text-lg text-ellipsis overflow-hidden w-[calc(100%)] whitespace-nowrap">{{ offer.title }}</p>
                <hr class="bg-black my-3">
                <p class="text-gray-500 dark:text-gray-300">{{ offer.condition }} • {{ offer.yearOfProduction }}</p>
                <p class="text-center text-2xl drop-shadow-lg font-bold text-white mix-blend-darken dark:mix-blend-lighten bg-gradient-to-br from-[#463691CC] from-40% to-[#E5A00ACC] mx-auto px-6 py-2 rounded-full mt-3">
                    <i class="fa-solid fa-sack-dollar me-2"></i>{{ offer.price.toLocaleString('pl-PL', { useGrouping: true }) }} <small>PLN</small>           
                </p>
            </div>            
        </div>
    </NuxtLink>
</template>

<script setup>
    const props = defineProps(['offer']);

    const { data: image } = await useFetch(`http://localhost:5271/api/image/uploadGalleryImages/${props.offer.advertisementID}`, { 
        responseType: 'json', 
        method: 'get',
        headers: {
            'Content-Type': 'application/json',
        },
        credentials: 'include'
    });
</script>