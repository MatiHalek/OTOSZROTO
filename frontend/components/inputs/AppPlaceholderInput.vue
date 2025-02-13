<template>
    <input type="text" v-model="model" class="focus:border-[#E5A00A] border-b-2 border-[#DDD] outline-none bg-[#EEEEEE] w-full p-2 dark:bg-transparent">
</template>

<script setup>
    const model = defineModel();
</script>