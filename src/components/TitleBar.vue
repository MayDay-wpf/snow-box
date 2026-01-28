<script setup lang="ts">
import { ref, onMounted } from "vue";

const platform = ref<string>("unknown");
const isMac = ref(false);

onMounted(() => {
  // 检测平台
  platform.value = navigator.platform.toLowerCase();
  isMac.value = platform.value.includes("mac");
});

const minimizeWindow = () => {
  // @ts-ignore
  if (window.electronAPI) {
    // @ts-ignore
    window.electronAPI.minimizeWindow();
  }
};

const maximizeWindow = () => {
  // @ts-ignore
  if (window.electronAPI) {
    // @ts-ignore
    window.electronAPI.maximizeWindow();
  }
};

const closeWindow = () => {
  // @ts-ignore
  if (window.electronAPI) {
    // @ts-ignore
    window.electronAPI.closeWindow();
  }
};
</script>

<template>
  <div class="title-bar" :class="{ 'title-bar-mac': isMac }">
    <div class="title-bar-drag-region">
      <div class="title-bar-title">
        <span class="app-name">Snow Box</span>
      </div>
    </div>
    <div v-if="!isMac" class="title-bar-controls">
      <button
        class="title-bar-button minimize"
        @click="minimizeWindow"
        title="最小化"
      >
        <svg width="12" height="12" viewBox="0 0 12 12">
          <rect x="0" y="5" width="12" height="2" fill="currentColor" />
        </svg>
      </button>
      <button
        class="title-bar-button maximize"
        @click="maximizeWindow"
        title="最大化"
      >
        <svg width="12" height="12" viewBox="0 0 12 12">
          <rect
            x="0"
            y="0"
            width="12"
            height="12"
            fill="none"
            stroke="currentColor"
            stroke-width="1.5"
          />
        </svg>
      </button>
      <button class="title-bar-button close" @click="closeWindow" title="关闭">
        <svg width="12" height="12" viewBox="0 0 12 12">
          <path
            d="M 0,0 L 12,12 M 12,0 L 0,12"
            stroke="currentColor"
            stroke-width="1.5"
          />
        </svg>
      </button>
    </div>
  </div>
</template>

<style scoped>
.title-bar {
  display: flex;
  align-items: center;
  justify-content: space-between;
  height: 32px;
  user-select: none;
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  z-index: 1000;
}

.title-bar-drag-region {
  flex: 1;
  display: flex;
  align-items: center;
  height: 100%;
  padding: 0 12px;
  -webkit-app-region: drag;
  app-region: drag;
}

.title-bar-mac .title-bar-drag-region {
  padding-left: 80px;
}

.title-bar-title {
  display: flex;
  align-items: center;
  gap: 8px;
  font-size: 13px;
  text-align: center;
  width: 100%;
  justify-content: center;
}

.app-name {
  font-weight: 500;
}

.title-bar-controls {
  display: flex;
  height: 100%;
  -webkit-app-region: no-drag;
  app-region: no-drag;
}

.title-bar-button {
  width: 46px;
  height: 100%;
  border: none;
  background: transparent;
  cursor: pointer;
  transition: background-color 0.15s ease;
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 0;
}

.title-bar-button:hover {
  background: rgba(128, 128, 128, 0.2);
}

.title-bar-button.close:hover {
  background: #e81123;
  color: white;
}

.title-bar-button:active {
  background: rgba(128, 128, 128, 0.3);
}

.title-bar-button.close:active {
  background: #c50f1f;
}
</style>
