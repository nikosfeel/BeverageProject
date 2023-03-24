<template>
    <div>
        <vue-snotify></vue-snotify>
        <router-view :key="this.$route.fullPath" />
    </div>
</template>