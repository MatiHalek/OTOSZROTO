<template>
    <div class="flex gap-3 w-full p-4 mt-5">
        <button class="bg-[#E5A00A] p-2 w-1/2 text-white" @click="editOffer()">Edytuj</button>
        <button class="bg-[#E32727] p-2 w-1/2 text-white" @click="deleteOffer()">Usuń</button>
    </div>
</template>

<script setup>
    const { id } = useRoute().params;

    async function deleteOffer() {
        if(id) {
            const response = await $fetch(`/api/test`, {
                method: 'post',
                body: {
                    id: id
                }
            });

            console.log(response.value);
        }
    }

    async function editOffer() {
        await navigateTo('/edytuj-ogloszenie/' + id);
    }
</script>