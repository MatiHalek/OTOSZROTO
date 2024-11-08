<template>
    <textarea 
        v-model="inputValue" required
        class="resize-none outline-none border-[#DDD] border-2 w-full p-1 min-h-[200px]">
    </textarea>
</template>

<script setup>
    const inputValue = defineModel();
</script>