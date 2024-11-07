<template>
    <div class="container mx-auto">
        <h1 class="text-center text-3xl font-bold p-4">Profil</h1>

        <hr>
        <h2 class="mb-5 pt-5 text-xl">Moje dane</h2>

        <VerticalGroup class="gap-3">
            <HorizontalGroup class="gap-3">
                <AppPlaceholderInput placeholder="Imię" v-model="data.name"/>
                <AppPlaceholderInput placeholder="Nazwisko" v-model="data.surname"/>
            </HorizontalGroup>

            <h3 class="border-b-2 border-[#DDD] outline-none bg-[#EEEEEE] w-full p-2">{{ user.email }}</h3>
            <h3 class="border-b-2 border-[#DDD] outline-none bg-[#EEEEEE] w-full p-2">{{ user.phone }}</h3>

            <ConfirmButton class="self-end w-[200px]" @click="SaveChanges()">Zapisz</ConfirmButton>
        </VerticalGroup>

        <hr class="mt-10">
        <h2 class="mb-5 pt-5 text-xl">Moje ogłoszenia</h2>

        <div class="h-[500px]">

        </div>
    </div>
</template>

<script setup>
    const user = useUserStore();

    const data = ref({
        name: user.name,
        surname: user.surname
    });

    async function SaveChanges() {
        const response = await $fetch(`http://localhost:5271/api/user/${user.userId}`, {
            method: 'put',
            credentials: 'include',
            responseType: 'json',
            body: {
                "Name": data.value.name,
                "Surname": data.value.surname,
                "Email": user.email,
                "PhoneNumber": user.phone
            } 
        });
    }
</script>

<style scoped>

</style>