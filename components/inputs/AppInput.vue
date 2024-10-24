<template>
    <input :type="type" class="outline-none border-solid border-2 border-[#DDD] text-base p-2 focus:border-[#E5A00A]">
</template>

<script setup>
    defineProps(['type']);
</script>