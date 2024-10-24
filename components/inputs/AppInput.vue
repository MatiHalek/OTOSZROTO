<template>
    <input :type="type" class="outline-none border-solid border-2 border-[#DDD] text-base p-1.5">
</template>

<script setup>
    defineProps(['type']);
</script>