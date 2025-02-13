<template>   
    <div class="w-full sm:w-[90%] h-fit shadow-[0px_0px_70px_-62px_rgba(66,68,90,1)] bg-white dark:bg-[#1E293B] p-10">
        <form @submit.prevent="GoToSearch()">
            <VerticalGroup class="gap-3">
                <AppPlaceholderInput placeholder="Wyszukaj..." v-model="searchValue"/>
              <div class="mt-24 flex flex-col sm:flex-row gap-5 sm:gap-0 justify-between items-center">
                    <p class="text-[#463691] font-semibold text-base"></p>
                    <button type="submit" class="font-semibold self-end bg-[#E5A00A] text-white p-2 w-full sm:w-40 rounded-full hover:shadow-special hover:text-[#463691] hover:bg-white transition-all duration-300"><i class="fa-solid fa-magnifying-glass me-2"></i>Szukaj</button>
                </div>
            </VerticalGroup>
        </form>
    </div>  
</template>

<script setup>
    const searchValue = ref('');

    async function GoToSearch() {
        if(searchValue.value && searchValue.value.trim().length !== 0) {
            await navigateTo('/szukaj/' + searchValue.value);
        }
    }
</script>