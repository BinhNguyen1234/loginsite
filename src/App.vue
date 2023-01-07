<script setup lang="ts">
  import GalaxyVue from './components/Galaxy.vue';
  import LoginModalVue from './components/LoginModal.vue';
</script>

<template>
    <div class="Main">
      <GalaxyVue></GalaxyVue>
      <LoginModalVue></LoginModalVue>
    </div>
</template>

<style lang="sass" scoped>
  .Main
    width: 100vw
    height: 100vh
</style>