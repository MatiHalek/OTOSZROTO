<template>
    <header class="px-[140px] h-[70px] flex items-center shadow-md justify-between">
        <div class="flex items-center gap-1">
            <img src="/img/logo.png" alt="Logo strony" width="50" height="50">
            <h1 class="text-2xl font-extrabold text-[#E5A00A]">
                <span class="text-[#463691]">OTO</span>SZROTO
            </h1>
        </div>

        <div class="flex gap-4 items-center text-base" v-if="isLogged == false">
            <NuxtLink :to="'/logowanie'">Zaloguj się</NuxtLink>
            |
            <NuxtLink :to="'/rejestracja'" class="p-1.5 bg-[#E5A00A] text-[#FFF]">Utwórz konto</NuxtLink>
        </div>

        <div v-else class="relative">
            <button class="p-2.5 px-5 bg-[#E5A00A] text-[#FFF] text-base" @click="isCollapsed = !isCollapsed">Moje konto</button>

            <div class="absolute bg-white p-3 border-2 border-t-0" v-show="isCollapsed">
                <ul class="flex flex-col gap-3">
                    <li>
                        placeforemail@gmail.com
                    </li>

                    <li>
                        <button class="bg-red-500 text-[#FFF] p-2 w-full">Wyloguj się</button>
                    </li>
                </ul>
            </div>
        </div>
    </header>
</template>

<script setup>
    const isLogged = ref(true);
    const isCollapsed = ref(false);
</script>