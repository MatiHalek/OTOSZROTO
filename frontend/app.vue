<template>
  <NuxtLayout>
    <NuxtPage />
  </NuxtLayout>
</template>

<script setup>
  const user = useUserStore()
  const response = await $fetch('http://localhost:5271/api/auth/user', { method: 'get', credentials: 'include', responseType: 'json' });

  if(response) {
    user.logIn();
  }
</script>
