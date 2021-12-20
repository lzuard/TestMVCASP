<template>
  <showcase v-bind="showCaseData" />
</template>

<script>
import Showcase from '@/components/Showcase'
import { useToast } from 'vue-toastification'

export default {
  name: 'AddressList',
  components: {
    Showcase
  },
  setup () {
    const toast = useToast()
    return { toast }
  },
  data: () => {
    return {
      showCaseData: {
        title: 'Список адресов',
        linkToCreate: '/address/create',
        createCaption: 'Создать адрес',
        tableHeaders: [
          '№',
          'Индекс',
          'Субъект',
          'Населенный пункт',
          'Улица',
          'Дом',
          'Строение',
          'Корпус',
          'Комната'
        ],
        tableData: [],
        sortTypes: [
          'Индекс',
          'Форма',
          'Тип'
        ]
      }
    }
  },
  created () {
    this.$api.address.getAddress()
      .then((data) => {
        this.showCaseData.tableData = data
      })
      .catch(() => {
        this.toast.error('Ошибка при загрузке адресов')
      })
  }
}
</script>
