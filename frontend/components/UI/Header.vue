<template>
    <header class="px-[20px] md:px-[50px] lg:px-[140px] h-[70px] flex items-center shadow-md justify-between">
        <div class="flex items-center gap-1">
            <img src="/img/logo.png" alt="Logo strony" width="50" height="50">
            <h1 class="text-2xl font-extrabold text-[#E5A00A]">
                <span class="text-[#463691]">OTO</span>SZROTO
            </h1>
        </div>

        <div class="block sm:hidden">
            <i class="fa-solid fa-bars fa-lg cursor-pointer" @click="isMobileCollapsed = !isMobileCollapsed"></i>
        </div>

        <div class="gap-4 items-center text-base hidden sm:flex" v-if="isLogged == false">
            <NuxtLink :to="'/logowanie'">Zaloguj się</NuxtLink>
            |
            <NuxtLink :to="'/rejestracja'" class="p-3 py-2 bg-[#E5A00A] text-[#FFF] rounded-sm">Utwórz konto</NuxtLink>
        </div>

        <div v-else class="relative hidden sm:block">
            <button class="p-2.5 px-5 bg-[#E5A00A] text-[#FFF] text-base rounded-sm" @click="isCollapsed = !isCollapsed">Moje konto</button>

            <div class="absolute bg-white p-3 border-2 border-t-0 right-0" v-show="isCollapsed">
                <ul class="flex flex-col gap-3">
                    <li>
                        placeforemail@gmail.com
                    </li>

                    <li>
                        <button class="bg-red-500 text-[#FFF] p-2 w-full rounded-sm">Wyloguj się</button>
                    </li>
                </ul>
            </div>
        </div>

        <div class="absolute left-0 top-[70px] bg-white w-full border-t-2 pt-5 px-4" v-show="isMobileCollapsed">
            <div v-if="isLogged == false">
                <NuxtLink :to="'/logowanie'">Zaloguj się</NuxtLink>
                |
                <NuxtLink :to="'/rejestracja'" class="p-3 py-2 bg-[#E5A00A] text-[#FFF] rounded-sm">Utwórz konto</NuxtLink>
            </div>

            <div v-else>
                <ul class="flex flex-col gap-3">
                    <li>
                        placeforemail@gmail.com
                    </li>

                    <li>
                        <button class="bg-red-500 text-[#FFF] p-2 w-full rounded-sm">Wyloguj się</button>
                    </li>
                </ul>
            </div>
        </div>
    </header>
</template>

<script setup>
    const isLogged = ref(false);
    const isCollapsed = ref(false);
    const isMobileCollapsed = ref(false);
</script>