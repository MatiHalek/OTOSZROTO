<template>
    <header class="z-20 px-[20px] md:px-[50px] lg:px-[140px] h-[70px] flex items-center shadow-md justify-between sticky top-0 bg-[#FFFC] dark:bg-[#000D] dark:text-white backdrop-blur-md">
        <div class="flex gap-2">
            <NuxtLink to="/" title="Strona główna OTOSZROTO">
                <div class="flex items-center gap-1 border-y-4 border-y-transparent hover:border-b-[#E5A00A] transition-all">           
                    <img src="/img/logo.png" alt="Logo strony" width="50" height="50">
                    <h1 class="text-2xl font-extrabold text-[#E5A00A]">
                        <span class="text-[#463691] dark:text-[#8772EB]">OTO</span>SZROTO
                    </h1>                   
                </div>
            </NuxtLink>
            <button @click="toggleDarkMode"><i class="fa-solid" :class="{'fa-sun' : isDark, 'fa-moon' : !isDark}" title="Przełącz motyw"></i></button>
        </div>
         

        <div class="block sm:hidden z-40" @click="isMobileCollapsed = !isMobileCollapsed">
            <i class="fa-solid fa-bars fa-lg cursor-pointer"></i>
        </div>

        <div class="gap-4 items-center text-base hidden sm:flex" v-if="isLogged == false">
            <NuxtLink :to="'/logowanie'" class="p-3 py-2 bg-transparent rounded-full hover:shadow-special hover:text-[#463691] hover:bg-white transition-all duration-300 hover:px-5">Zaloguj się</NuxtLink>
            |
            <NuxtLink :to="'/rejestracja'" class="p-3 py-2 bg-[#E5A00A] text-[#FFF] rounded-full px-5 hover:shadow-special hover:bg-white hover:text-[#463691] transition-all duration-300">Utwórz konto</NuxtLink>
        </div>

        <div v-else class="relative hidden sm:block">
            <NuxtLink :to="'/dodaj-ogloszenie'" class="bg-transparent me-4 p-3 py-2 rounded-full hover:shadow-special hover:bg-white hover:text-[#463691] transition-all duration-300 hover:px-5">Dodaj ogłoszenie</NuxtLink>
            |
            <button class="ms-4 p-3 py-2 bg-[#E5A00A] text-[#FFF] rounded-full px-5 hover:shadow-special hover:bg-white hover:bg-white hover:text-[#463691] transition-all duration-300" @click.stop="isCollapsed = !isCollapsed">Moje konto</button>

            <div class="absolute bg-white dark:bg-[#000] p-3 shadow-lg rounded-lg right-0 top-[70px] shadow-md" v-show="isCollapsed" v-click-outside="hideDropdown">
                <ul class="flex flex-col gap-3">
                    <li>
                        Zalogowany jako: <span class="font-semibold">{{ user.email }}</span>
                    </li>

                    <li>
                        <button class="bg-[#E5A00A] text-[#FFF] w-full rounded-full hover:shadow-special hover:bg-white hover:text-[#463691] transition-all duration-300">
                            <NuxtLink :to="'/profil'" class="size-full block p-2 px-5">Mój profil</NuxtLink>
                        </button>
                    </li>

                    <li>
                        <button class="bg-red-500 text-[#FFF] p-2 w-full rounded-full px-5 hover:shadow-special hover:bg-white hover:text-[#463691] transition-all duration-300" @click="LogOut()">Wyloguj się</button>
                    </li>
                </ul>
            </div>
        </div>

        <div class="block sm:hidden absolute left-0 top-[70px] bg-[#FFFE] dark:bg-[#000E] backdrop-blur-md w-full shadow-lg pt-5 pb-5 px-4" v-show="isMobileCollapsed">
            <div v-if="isLogged == false" class="flex gap-3 items-center">
                <NuxtLink :to="'/logowanie'" class="p-3 py-2 bg-transparent rounded-full hover:shadow-special hover:bg-white hover:text-[#463691] transition-all duration-300 hover:px-5">Zaloguj się</NuxtLink>
                |
                <NuxtLink :to="'/rejestracja'" class="p-3 py-2 bg-[#E5A00A] text-[#FFF] rounded-full px-5 hover:shadow-special hover:bg-white hover:text-[#463691] transition-all duration-300">Utwórz konto</NuxtLink>
            </div>

            <div v-else class="bg-transparent px-3">
                <ul class="flex flex-col gap-3">
                    <li>
                        Zalogowany jako: <span class="font-semibold">{{ user.email }}</span>
                    </li>

                    <li>
                        <button class="bg-[#1E90FF] text-[#FFF] w-full rounded-full hover:shadow-special hover:bg-white hover:text-[#463691] transition-all duration-300">
                            <NuxtLink :to="'/dodaj-ogloszenie'" class="size-full block p-2 px-5">Dodaj ogłoszenie</NuxtLink>
                        </button>
                    </li>

                    <li>
                        <button class="bg-[#E5A00A] text-[#FFF] w-full rounded-full hover:shadow-special hover:bg-white hover:text-[#463691] transition-all duration-300">
                            <NuxtLink :to="'/profil'" class="size-full block p-2 px-5">Mój profil</NuxtLink>
                        </button>
                    </li>

                    <li>
                        <button class="bg-red-500 text-[#FFF] p-2 w-full rounded-full hover:shadow-special hover:bg-white hover:text-[#463691] transition-all duration-300" @click="LogOut()">Wyloguj się</button>
                    </li>
                </ul>
            </div>
        </div>
    </header>
</template>

<script setup>
    const user = useUserStore()
    const isLogged = ref(user.isLogged);

    const isCollapsed = ref(false);
    const isMobileCollapsed = ref(false);

    function hideDropdown() {
        isCollapsed.value = false;
    }

    async function LogOut() {
        const response = await $fetch('http://localhost:5271/api/auth/logout', { method: 'post', credentials: 'include', responseType: 'json' });

        if(response.message == 'success') {
            isLogged.value = false;

            user.logOut();
            await navigateTo('/');
        }
    }

    const isDark = ref(false);

    const toggleDarkMode = () => {
    isDark.value = !isDark.value;
    document.documentElement.classList.toggle('dark', isDark.value);
    localStorage.setItem('theme', isDark.value ? 'dark' : 'light');
    };

    onMounted(() => {
    const savedTheme = localStorage.getItem('theme');
    isDark.value = savedTheme === 'dark';
    document.documentElement.classList.toggle('dark', isDark.value);
    });
</script>