<template>
    <input :type="type" :id="id" class="outline-none rounded-lg border-solid border-2 border-[#DDD] text-base p-2 focus:border-[#E5A00A]">
</template>

<script setup>
    defineProps(['type', 'id']);
</script>