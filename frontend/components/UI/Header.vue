<template>
    <header class="px-[140px] h-[70px] flex items-center shadow-md justify-between">
        <h1 class="text-2xl font-extrabold text-[#E5A00A]">
            <span class="text-[#463691]">OTO</span>SZROTO
        </h1>

        <div class="flex gap-4 items-center text-base" v-if="isLogged == false">
            <NuxtLink :to="'/logowanie'">Zaloguj się</NuxtLink>
            |
            <NuxtLink :to="'/rejestracja'" class="p-1.5 bg-[#E5A00A] text-[#FFF]">Utwórz konto</NuxtLink>
        </div>

        <div v-else>
            <NuxtLink :to="'/profil'" class="p-2.5 px-5 bg-[#E5A00A] text-[#FFF] text-base">Moje konto</NuxtLink>
        </div>
    </header>
</template>

<script setup>
    const isLogged = ref(false);
</script>