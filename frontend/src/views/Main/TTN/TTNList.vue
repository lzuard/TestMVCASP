<template>
  <showcase v-bind="showCaseData" />
</template>

<script>
import dayjs from 'dayjs'
import Showcase from '@/components/Showcase'
import { TTN_TYPES } from '@/services/dictionaries'

export default {
  name: 'TTNList',
  components: {
    Showcase
  },
  data: () => {
    return {
      showCaseData: {
        title: 'Список ТТН',
        linkToCreate: '/ttn/create',
        createCaption: 'Создать ТТН',
        tableHeaders: [
          '№',
          'Номер ТТН',
          'Тип',
          'Форма',
          'Дата оформления'
        ],
        tableData: [],
        sortTypes: [
          'Номер ТТН',
          'Тип',
          'Форма'
        ]
      }
    }
  },
  created () {
    this.$api.ttn.getTTN()
      .then((data) => {
        this.getHandlingData(data)
        this.showCaseData.tableData = data
      })
      .catch(() => {
        this.toast.error('Ошибка при загрузке ТТН')
      })
  },
  methods: {
    getHandlingData (data) {
      data.forEach(item => {
        item.type = TTN_TYPES[item.type]
        item.date = dayjs(item.date).locale('ru-ru').format('DD/MM/YYYY')
      })
    }
  }
}
</script>
