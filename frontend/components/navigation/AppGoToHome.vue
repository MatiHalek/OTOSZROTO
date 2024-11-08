<template>
    <button class="z-50" @click.prevent="GoHome()">
        <i class="fa-solid fa-house fa-lg"></i>
    </button> 
</template>

<script setup>
    async function GoHome() {
        await navigateTo('/');  
    }
</script>