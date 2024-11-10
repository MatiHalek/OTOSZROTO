<template>
   <footer class="flex flex-wrap px-3 pb-2 bg-gradient-to-b from-[#463691] via-[#463691B0] to-[#463691cc] text-white">
    <article class="container mx-auto mb-4">
        <section class="flex flex-wrap">
            <div class="w-full sm:w-1/2 md:w-1/3 pt-5 text-lg">
                <h3 class="text-center text-2xl drop-shadow-lg font-bold bg-white mb-5 mt-8 px-6 py-2 rounded-full inline-flex">
                    <span class="text-transparent bg-gradient-to-br from-[#463691CC] bg-clip-text from-40% to-[#E5A00ACC]">OTOSZROTO</span>                       
                </h3>
                <p class="mb-2"><NuxtLink :to="{path: '/'}" class="no-underline mb-2 hover:text-[#E5A00A] hover:font-bold transition-all"><i class="fa-solid fa-house me-2"></i>Strona główna</NuxtLink></p>
                <p class="mb-2"><NuxtLink :to="{path: '/', hash: '#homePageAboutUs'}" class="no-underline mb-2 hover:text-[#E5A00A] hover:font-bold transition-all"><i class="fa-solid fa-circle-info me-2"></i>O nas</NuxtLink></p>
                <p class="mb-2"><NuxtLink :to="{path: '/', hash: '#homePageSearch'}" class="no-underline mb-2 hover:text-[#E5A00A] hover:font-bold transition-all"><i class="fa-solid fa-magnifying-glass me-2"></i>Szukaj</NuxtLink></p>
                <p class="mb-2"><NuxtLink :to="{path: '/', hash: '#homePageLatestOffers'}" class="no-underline mb-2 hover:text-[#E5A00A] hover:font-bold transition-all"><i class="fa-solid fa-car me-2"></i>Najnowsze oferty</NuxtLink></p>
            </div>
            <div class="w-full sm:w-1/2 md:w-1/3 pt-5 text-lg">
                <h3 class="text-center text-2xl drop-shadow-lg font-bold bg-white mb-5 mt-8 px-6 py-2 rounded-full inline-flex">
                    <span class="text-transparent bg-gradient-to-br from-[#463691CC] bg-clip-text from-40% to-[#E5A00ACC]">Znajdź nas</span>                       
                </h3>
                <p class='mb-2 text-lg'><a href='https://github.com/MatiHalek/' target='_blank' class='text-white no-underline hover:text-[#E5A00A] hover:font-bold transition-all'><i class="fa-brands fa-github me-2"></i>Vistaaa</a></p>
                <p class="mb-2 text-lg"><a href="https://github.com/Uzyxen/" target="_blank" class="text-white no-underline hover:text-[#E5A00A] hover:font-bold transition-all"><i class="fa-brands fa-github me-2"></i>Uzyxen</a></p>
                <p class="mb-2 text-lg"><a href="https://github.com/MagisterLysaGlowa/" target="_blank" class="text-white no-underline hover:text-[#E5A00A] hover:font-bold transition-all"><i class="fa-brands fa-github me-2"></i>MagisterLysaGlowa</a></p>
                <p class="mb-2 text-lg"><a href="https://github.com/klaale182/" target="_blank" class="text-white no-underline hover:text-[#E5A00A] hover:font-bold transition-all"><i class="fa-brands fa-github me-2"></i>klaale182</a></p>
            </div>
            <div class="w-full sm:w-1/2 md:w-1/3 pt-5 text-lg">
                <h3 class="text-center text-2xl drop-shadow-lg font-bold bg-white mb-5 mt-8 px-6 py-2 rounded-full inline-flex">
                    <span class="text-transparent bg-gradient-to-br from-[#463691CC] bg-clip-text from-40% to-[#E5A00ACC]">Kontakt</span>                       
                </h3>
                <p class="text-white mb-2"><i class="fa-solid fa-briefcase me-2"></i>Grupa OTOSZROTO S.A.</p>
                <p class="text-white mb-2"><i class="fa-solid fa-location-dot me-2"></i>Antyptasia 666, 11-000 Nod3D</p>
                <p class="text-white mb-2"><i class="fa-solid fa-phone me-2"></i><a href="tel:123456789" class="no-underline hover:text-[#E5A00A] hover:font-bold transition-all">123 456 789</a></p>
                <p class="text-white mb-2"><i class="fa-solid fa-envelope me-2"></i><a href="mailto:otoszroto@gmail.com" class="no-underline hover:text-[#E5A00A] hover:font-bold transition-all">otoszroto@gmail.com</a></p>
            </div>
        </section>
        <div class="text-center my-6">
            <p class='mb-1 text-center font-bold'><span v-html="updateMessage"></span><span v-if="hasError">(</span><button v-if="hasError" @click="GetLatestRelease" class="hover:text-[#E5A00A] transition-all">Retry</button><span v-if="hasError">)</span><span v-if="isUpToDate">(</span><button v-if="isUpToDate" @click="GetLatestRelease" class="hover:text-[#E5A00A] transition-all">Check again</button><span v-if="isUpToDate">)</span></p>
            <p class='text-center text-white'><i class='bi bi-calendar-check-fill mr-2'></i><a class="no-underline hover:text-[#E5A00A] hover:font-bold transition-all" :href="'https://github.com/MatiHalek/OTOSZROTO/releases/tag/v'+majorVersion+'.'+minorVersion+'.'+patchVersion" target="_blank">v{{majorVersion }}.{{ minorVersion }}.{{ patchVersion }}</a> ({{ releaseDate.toLocaleDateString('pl-PL', {day: 'numeric', month: 'numeric', year: 'numeric'})}})</p> 
        </div>
        
    </article>
    <p class='w-full mb-4 text-sm'>&copy; 2024 Grupa OTOSZROTO. Wszelkie prawa zastrzeżone. Wszystkie znaki handlowe są własnością ich prawnych właścicieli w serwisie OTOSZROTO i innych firmach.</p>
    </footer>
</template>
<script setup>
        const updateMessage = ref('');
        const hasError = ref(false);
        const isUpToDate = ref(false);
        const majorVersion = 1;
        const minorVersion = 0;
        const patchVersion = 1;
        const releaseDate = new Date(2024, 10, 10);
        const owner = 'MatiHalek';
        const repo = 'OTOSZROTO';
        async function GetLatestRelease() {
            isUpToDate.value = false;
            hasError.value = false;
            updateMessage.value = '<i class="fa-solid fa-rotate me-2"></i>Checking for updates...';
            try {
                const response = await fetch(`https://api.github.com/repos/${owner}/${repo}/releases/latest`);
                if (!response.ok) {
                    throw new Error('Error fetching latest release');                  
                }
                const release = await response.json();
                const version = release.tag_name;
                const date = new Date(release.published_at);
                const [major, minor, patch] = version.split('.').map(Number);
                if (major > majorVersion || minor > minorVersion || patch > patchVersion) {
                    updateMessage.value = `<i class="fa-solid fa-circle-check me-2"></i>New version available: <a href="${release.html_url}" class="text-[#E5A00A] hover:text-[#FFF] transition-all" target="_blank">${version}</a> (${date.toLocaleDateString('pl-PL', {day: 'numeric', month: 'numeric', year: 'numeric'})})`;
                } else {
                    isUpToDate.value = true;
                    updateMessage.value = '<i class="fa-solid fa-circle-check me-2"></i>You\'re up to date ';
                }
            } catch (error) {
                hasError.value = true;
                updateMessage.value = '<i class="fa-solid fa-circle-xmark me-2"></i>Failed to check for updates ';  
            }
        }
        GetLatestRelease();
</script>