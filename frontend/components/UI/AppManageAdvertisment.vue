<template>
    <Teleport to="#teleports">
        <DeleteOfferModal :isVisible="isModalVisible" @close="isModalVisible = false" :id="id" />
    </Teleport>

    <div class="flex gap-1 w-full p-4 mt-5">
        <button class="bg-[#E5A00A] font-semibold p-2 w-1/2 text-white hover:shadow-special rounded-full hover:bg-white hover:text-[#463691] transition-all duration-300" @click="editOffer()"><i class="fa-solid fa-pen me-2"></i>Edytuj</button>
        <button class="bg-[#E32727] font-semibold p-2 w-1/2 text-white hover:shadow-special rounded-full hover:bg-white hover:text-[#463691] transition-all duration-300" @click="deleteOffer()"><i class="fa-solid fa-trash me-2"></i>Usuń</button>
    </div>
</template>

<script setup>
    const { id } = useRoute().params;

    const isModalVisible = ref(false);
    
    function deleteOffer() {
        isModalVisible.value = true;
    }

    async function editOffer() {
        await navigateTo('/edytuj-ogloszenie/' + id);
    }
</script>