<template>
    <input 
        type="text" 
        v-model="inputValue" required
        class="outline-none border-[#DDD] border-2 w-full p-1 h-10">
</template>

<script setup>
    const inputValue = defineModel();
</script>